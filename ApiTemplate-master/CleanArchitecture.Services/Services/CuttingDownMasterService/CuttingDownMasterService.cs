using CleanArchitecture.DataAccess.IUnitOfWorks;
using CleanArchitecture.DataAccess.Models.Fact_models;
using CleanArchitecture.Services.DTOs.CuttingDownAddDto;
using CleanArchitecture.Services.DTOs.CuttingDownMasterSearchDto;
using CleanArchitecture.Services.Interfaces.IcuttingDownMasterService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Services.Services.CuttingDownMasterService
{
    public class CuttingDownMasterService : ICuttingDownMasterService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CuttingDownMasterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddManualTicketAsync(AddCuttingDownDto dto)
        {
            // Step 1: Create Cutting_Down_Header
            var header = new Cutting_Down_Header
            {
                Channel_Key = dto.ChannelKey,
                Cutting_Down_Problem_Type_Key = dto.ProblemTypeKey,
                ActualCreatetDate = dto.ActualCreatedDate,
                ActualEndDate = dto.ActualEndDate,
                IsPlanned = dto.IsPlanned,
                IsGlobal = dto.IsGlobal,
                PlannedStartDTS = dto.PlannedStartDTS,
                PlannedEndDTS = dto.PlannedEndDTS,
                IsActive = true,
                CreateSystemUserID = dto.CreateSystemUserID,
                UpdateSystemUserID = dto.UpdateSystemUserID,
                SynchCreateDate = DateTime.UtcNow,
                SynchUpdateDate = DateTime.UtcNow
            };

            await _unitOfWork.Repository<Cutting_Down_Header>().AddAsync(header);
            await _unitOfWork.SaveAsync(); // Save to get Cutting_Down_Key

            // Step 2: Create Cutting_Down_Detail (optional)
            if (dto.NetworkElementKey.HasValue)
            {
                var detail = new Cutting_Down_Detail
                {
                    Cutting_Down_Key = header.Cutting_Down_Key,
                    Network_Element_Key = dto.NetworkElementKey,
                    ActualCreatetDate = dto.ActualCreatedDate,
                    ActualEndDate = dto.ActualEndDate,
                    ImpactedCustomers = dto.ImpactedCustomers
                };

                await _unitOfWork.Repository<Cutting_Down_Detail>().AddAsync(detail);
            }

            await _unitOfWork.SaveAsync();
        }



        public async Task<CuttingDownSearchResultDto> SearchTicketsAsync(CuttingDownSearchDto dto)
        {
            var query = _unitOfWork.Repository<Cutting_Down_Header>()
                .AsQueryable()
                .Include(h => h.Channel)
                .Include(h => h.Problem_Type)
                .Include(h => h.Cutting_Down_Details)
                    .ThenInclude(d => d.Network_Element)
                .Where(h => h.IsActive);

            // Apply filters
            if (dto.ChannelKey.HasValue)
                query = query.Where(h => h.Channel_Key == dto.ChannelKey.Value);

            if (dto.ProblemTypeKey.HasValue)
                query = query.Where(h => h.Cutting_Down_Problem_Type_Key == dto.ProblemTypeKey.Value);
            //test
            if (dto.FromDate.HasValue)
                query = query.Where(h => h.ActualCreatetDate >= dto.FromDate.Value);
            if (dto.ToDate.HasValue)
                query = query.Where(h => h.ActualCreatetDate <= dto.ToDate.Value);
            if (dto.IsClosed.HasValue)
            {
                if (dto.IsClosed.Value)
                    query = query.Where(h => h.ActualEndDate != null);
                else
                    query = query.Where(h => h.ActualEndDate == null);
            }


            // Hierarchy filter based on FilterLevel and FilterKey
            if (dto.FilterLevel.HasValue && dto.FilterKey.HasValue)
            {
                var key = dto.FilterKey.Value;

                switch (dto.FilterLevel.Value)
                {
                    case HierarchyLevel.Governrate:
                        query = query.Where(h => h.Cutting_Down_Details.Any(d =>
                            d.Network_Element.Parent_Network_Element != null &&
                            d.Network_Element.Parent_Network_Element.Parent_Network_Element != null &&
                            d.Network_Element.Parent_Network_Element.Parent_Network_Element.Parent_Network_Element != null &&
                            d.Network_Element.Parent_Network_Element.Parent_Network_Element.Parent_Network_Element.Network_Element_Key == key));
                        break;

                    case HierarchyLevel.Sector:
                        query = query.Where(h => h.Cutting_Down_Details.Any(d =>
                            d.Network_Element.Parent_Network_Element != null &&
                            d.Network_Element.Parent_Network_Element.Parent_Network_Element != null &&
                            d.Network_Element.Parent_Network_Element.Parent_Network_Element.Network_Element_Key == key));
                        break;

                    case HierarchyLevel.Zone:
                        query = query.Where(h => h.Cutting_Down_Details.Any(d =>
                            d.Network_Element.Parent_Network_Element != null &&
                            d.Network_Element.Parent_Network_Element.Network_Element_Key == key));
                        break;

                    case HierarchyLevel.City:
                        query = query.Where(h => h.Cutting_Down_Details.Any(d =>
                            d.Network_Element.Network_Element_Key == key));
                        break;

                    case HierarchyLevel.Station:
                        query = query.Where(h => h.Cutting_Down_Details.Any(d =>
                            d.Network_Element.Child_Elements.Any(c => c.Network_Element_Key == key)));
                        break;

                    case HierarchyLevel.Tower:
                        query = query.Where(h => h.Cutting_Down_Details.Any(d =>
                            d.Network_Element.Child_Elements.Any(c =>
                                c.Child_Elements.Any(tower => tower.Network_Element_Key == key))));
                        break;

                    case HierarchyLevel.Cabin:
                        query = query.Where(h => h.Cutting_Down_Details.Any(d =>
                            d.Network_Element.Child_Elements.Any(c =>
                                c.Child_Elements.Any(t =>
                                    t.Child_Elements.Any(cabin => cabin.Network_Element_Key == key)))));
                        break;

                    case HierarchyLevel.Cable:
                        query = query.Where(h => h.Cutting_Down_Details.Any(d =>
                            d.Network_Element.Child_Elements.Any(c =>
                                c.Child_Elements.Any(t =>
                                    t.Child_Elements.Any(c =>
                                        c.Child_Elements.Any(cable => cable.Network_Element_Key == key))))));
                        break;

                    case HierarchyLevel.Block:
                        query = query.Where(h => h.Cutting_Down_Details.Any(d =>
                            d.Network_Element.Child_Elements.Any(c =>
                                c.Child_Elements.Any(t =>
                                    t.Child_Elements.Any(c =>
                                        c.Child_Elements.Any(bl =>
                                            bl.Child_Elements.Any(block => block.Network_Element_Key == key)))))));
                        break;

                    case HierarchyLevel.Building:
                        query = query.Where(h => h.Cutting_Down_Details.Any(d =>
                            d.Network_Element.Child_Elements.Any(c =>
                                c.Child_Elements.Any(t =>
                                    t.Child_Elements.Any(c =>
                                        c.Child_Elements.Any(bl =>
                                            bl.Child_Elements.Any(bld =>
                                                bld.Child_Elements.Any(building => building.Network_Element_Key == key))))))));
                        break;

                    case HierarchyLevel.Flat:
                        query = query.Where(h => h.Cutting_Down_Details.Any(d =>
                            d.Network_Element.Child_Elements.Any(c =>
                                c.Child_Elements.Any(t =>
                                    t.Child_Elements.Any(c =>
                                        c.Child_Elements.Any(bl =>
                                            bl.Child_Elements.Any(bld =>
                                                bld.Child_Elements.Any(flt =>
                                                    flt.Network_Element_Key == key))))))));
                        break;

                    case HierarchyLevel.Subscription:
                        // Two types of subscriptions (individual and corporate)
                        query = query.Where(h => h.Cutting_Down_Details.Any(d =>
                            d.Network_Element.Child_Elements.Any(c =>
                                c.Child_Elements.Any(t =>
                                    t.Child_Elements.Any(cab =>
                                        cab.Child_Elements.Any(cabn =>
                                            cabn.Child_Elements.Any(sub =>
                                                sub.Network_Element_Key == key)))))));
                        break;

                    default:
                        // No filter or unknown level
                        break;
                }
            }


            // Pagination
            var totalCount = await query.CountAsync();

            var resultItems = await query
                .Skip((dto.PageNumber - 1) * dto.PageSize)
                .Take(dto.PageSize)
                .Select(h => new CuttingDownResultDto
                {
                    CuttingDownKey = h.Cutting_Down_Key,
                    IncidentId = h.Cutting_Down_Incident_ID,
                    ChannelName = h.Channel.Channel_Name,
                    ProblemTypeName = h.Problem_Type.Problem_Type_Name,
                    CreatedAt = h.ActualCreatetDate,
                    EndedAt = h.ActualEndDate,
                    IsGlobal = h.IsGlobal,
                    IsPlanned = h.IsPlanned,
                    ImpactedCustomers=h.Cutting_Down_Details.Sum(d => d.ImpactedCustomers),

                })
                .ToListAsync();

            return new CuttingDownSearchResultDto
            {
                TotalCount = totalCount,
                PageNumber = dto.PageNumber,
                PageSize = dto.PageSize,
                Results = resultItems
            };
        }


        public async Task<CuttingDownResultDto> GetTicketByIdAsync(int id)
        {
            var header = await _unitOfWork.Repository<Cutting_Down_Header>()
                .AsQueryable()
                .Include(h => h.Channel)
                .Include(h => h.Problem_Type)
                .Include(h => h.Cutting_Down_Details)
                    .ThenInclude(d => d.Network_Element)
                        .ThenInclude(ne => ne.Network_Element_Type) // Include the network element type
                .FirstOrDefaultAsync(h => h.Cutting_Down_Key == id && h.IsActive);

            if (header == null)
                return null; // or throw new KeyNotFoundException($"Ticket with ID {id} not found.");

            var firstDetail = header.Cutting_Down_Details.FirstOrDefault();

            return new CuttingDownResultDto
            {
                CuttingDownKey = header.Cutting_Down_Key,
                IncidentId = header.Cutting_Down_Incident_ID,
                ChannelName = header.Channel?.Channel_Name ?? string.Empty,
                ProblemTypeName = header.Problem_Type?.Problem_Type_Name ?? string.Empty,
                CreatedAt = header.ActualCreatetDate,
                EndedAt = header.ActualEndDate,
                IsGlobal = header.IsGlobal,
                IsPlanned = header.IsPlanned,
                ImpactedCustomers = header.Cutting_Down_Details.Sum(d => d.ImpactedCustomers),

                NetworkElementName = firstDetail?.Network_Element?.Network_Element_Name,
            };
        }




    }
}

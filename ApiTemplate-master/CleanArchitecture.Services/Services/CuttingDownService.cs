using CleanArchitecture.DataAccess.IUnitOfWorks;
using CleanArchitecture.DataAccess.Models.Fact_models;
using CleanArchitecture.DataAccess.Models.Staging_models;
using CleanArchitecture.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Services.Services
{
    public class CuttingDownService :ICuttingDownService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CuttingDownService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public async Task<object> TransferCuttingDownDataAsync()
        //{
        //    // Fetch all records from CuttingDownA and CuttingDownB
        //    var cuttingDownARecords = await _unitOfWork.Repository<CuttingDownA>().GetAllAsync();
        //    var cuttingDownBRecords = await _unitOfWork.Repository<CuttingDownB>().GetAllAsync();

        //    // Track the number of transferred records
        //    int transferredA = 0;
        //    int transferredB = 0;

        //    // Insert records into Cutting_Down_Header and Cutting_Down_Detail for CuttingDownA
        //    foreach (var aRecord in cuttingDownARecords)
        //    {
        //        if (ShouldIgnoreCuttingDownA(aRecord))
        //        {
        //            await InsertIgnoredCuttingDownRecord(aRecord, "CuttingDownA");
        //            continue;
        //        }

        //        var cuttingDownHeaderA = new Cutting_Down_Header
        //        {
        //            Cutting_Down_Incident_ID = aRecord.Cutting_Down_A_Incident_ID,
        //            Channel_Key = 1,
        //            Cutting_Down_Problem_Type_Key = aRecord.Problem_Type_Key,
        //            ActualCreatetDate = aRecord.CreateDate,
        //            ActualEndDate = aRecord.EndDate,
        //            IsPlanned = aRecord.IsPlanned,
        //            IsGlobal = aRecord.IsGlobal,
        //            PlannedStartDTS = aRecord.PlannedStartDTS,
        //            PlannedEndDTS = aRecord.PlannedEndDTS,
        //            IsActive = true,
        //            CreateSystemUserID = 1,
        //            UpdateSystemUserID = 1
        //        };

        //        await _unitOfWork.Repository<Cutting_Down_Header>().AddAsync(cuttingDownHeaderA);
        //        await _unitOfWork.SaveAsync();

        //        var cuttingDownDetailA = new Cutting_Down_Detail
        //        {
        //            Cutting_Down_Key = cuttingDownHeaderA.Cutting_Down_Key,
        //            Network_Element_Key = aRecord.Network_Element_Key,
        //            ActualCreatetDate = aRecord.CreateDate,
        //            ActualEndDate = aRecord.EndDate ?? aRecord.CreateDate,
        //            ImpactedCustomers = 100
        //        };

        //        await _unitOfWork.Repository<Cutting_Down_Detail>().AddAsync(cuttingDownDetailA);
        //        await _unitOfWork.SaveAsync();

        //        transferredA++;  // Increment the count for CuttingDownA records
        //    }

        //    // Insert records into Cutting_Down_Header and Cutting_Down_Detail for CuttingDownB
        //    foreach (var bRecord in cuttingDownBRecords)
        //    {
        //        if (ShouldIgnoreCuttingDownB(bRecord))
        //        {
        //            await InsertIgnoredCuttingDownRecord(bRecord, "CuttingDownB");
        //            continue;
        //        }

        //        var cuttingDownHeaderB = new Cutting_Down_Header
        //        {
        //            Cutting_Down_Incident_ID = bRecord.Cutting_Down_B_Incident_ID,
        //            Channel_Key = 2,
        //            Cutting_Down_Problem_Type_Key = bRecord.Problem_Type_Key,
        //            ActualCreatetDate = bRecord.CreateDate,
        //            ActualEndDate = bRecord.EndDate,
        //            IsPlanned = bRecord.IsPlanned,
        //            IsGlobal = bRecord.IsGlobal,
        //            PlannedStartDTS = bRecord.PlannedStartDTS,
        //            PlannedEndDTS = bRecord.PlannedEndDTS,
        //            IsActive = true,
        //            CreateSystemUserID = 1,
        //            UpdateSystemUserID = 1
        //        };

        //        await _unitOfWork.Repository<Cutting_Down_Header>().AddAsync(cuttingDownHeaderB);
        //        await _unitOfWork.SaveAsync();

        //        var cuttingDownDetailB = new Cutting_Down_Detail
        //        {
        //            Cutting_Down_Key = cuttingDownHeaderB.Cutting_Down_Key,
        //            Network_Element_Key = bRecord.Network_Element_Key,
        //            ActualCreatetDate = bRecord.CreateDate,
        //            ActualEndDate = bRecord.EndDate ?? bRecord.CreateDate,
        //            ImpactedCustomers = 50
        //        };

        //        await _unitOfWork.Repository<Cutting_Down_Detail>().AddAsync(cuttingDownDetailB);
        //        await _unitOfWork.SaveAsync();

        //        transferredB++;  // Increment the count for CuttingDownB records
        //    }

        //    // Return the counts of records transferred
        //    return new
        //    {
        //        CuttingDownARecordsTransferred = transferredA,
        //        CuttingDownBRecordsTransferred = transferredB
        //    };
        //}



        public async Task<object> TransferCuttingDownDataAsync()
        {
            // Fetch all records from Staging
            var cuttingDownARecords = await _unitOfWork.Repository<CuttingDownA>().GetAllAsync();
            var cuttingDownBRecords = await _unitOfWork.Repository<CuttingDownB>().GetAllAsync();

            // Fetch existing headers from Fact (for duplication check)
            var existingHeaders = await _unitOfWork.Repository<Cutting_Down_Header>().GetAllAsync();

            int transferredA = 0;
            int transferredB = 0;

            // Process CuttingDownA (Channel_Key = 1)
            foreach (var aRecord in cuttingDownARecords)
            {
                bool existsInFact = existingHeaders.Any(h =>
                    h.Cutting_Down_Incident_ID == aRecord.Cutting_Down_A_Incident_ID &&
                    h.Channel_Key == 1);

                if (existsInFact)
                    continue; // Already processed, skip

                //if (ShouldIgnoreCuttingDownA(aRecord))
                //{
                //    await InsertIgnoredCuttingDownRecord(aRecord, "CuttingDownA");
                //    continue;
                //}

                var cuttingDownHeaderA = new Cutting_Down_Header
                {
                    Cutting_Down_Incident_ID = aRecord.Cutting_Down_A_Incident_ID,
                    Channel_Key = 1,
                    Cutting_Down_Problem_Type_Key = aRecord.Problem_Type_Key,
                    ActualCreatetDate = aRecord.CreateDate,
                    ActualEndDate = aRecord.EndDate,
                    IsPlanned = aRecord.IsPlanned,
                    IsGlobal = aRecord.IsGlobal,
                    PlannedStartDTS = aRecord.PlannedStartDTS,
                    PlannedEndDTS = aRecord.PlannedEndDTS,
                    IsActive = true,
                    CreateSystemUserID = 1,
                    UpdateSystemUserID = 1
                };

                await _unitOfWork.Repository<Cutting_Down_Header>().AddAsync(cuttingDownHeaderA);
                await _unitOfWork.SaveAsync();

                var cuttingDownDetailA = new Cutting_Down_Detail
                {
                    Cutting_Down_Key = cuttingDownHeaderA.Cutting_Down_Key,
                    Network_Element_Key = aRecord.Network_Element_Key,
                    ActualCreatetDate = aRecord.CreateDate,
                    ActualEndDate = aRecord.EndDate ?? aRecord.CreateDate,
                    ImpactedCustomers = 100
                };

                await _unitOfWork.Repository<Cutting_Down_Detail>().AddAsync(cuttingDownDetailA);
                await _unitOfWork.SaveAsync();

                transferredA++;
            }

            // Process CuttingDownB (Channel_Key = 2)
            foreach (var bRecord in cuttingDownBRecords)
            {
                bool existsInFact = existingHeaders.Any(h =>
                    h.Cutting_Down_Incident_ID == bRecord.Cutting_Down_B_Incident_ID &&
                    h.Channel_Key == 2);

                if (existsInFact)
                    continue; // Already processed, skip

                //if (ShouldIgnoreCuttingDownB(bRecord))
                //{
                //    await InsertIgnoredCuttingDownRecord(bRecord, "CuttingDownB");
                //    continue;
                //}

                var cuttingDownHeaderB = new Cutting_Down_Header
                {
                    Cutting_Down_Incident_ID = bRecord.Cutting_Down_B_Incident_ID,
                    Channel_Key = 2,
                    Cutting_Down_Problem_Type_Key = bRecord.Problem_Type_Key,
                    ActualCreatetDate = bRecord.CreateDate,
                    ActualEndDate = bRecord.EndDate,
                    IsPlanned = bRecord.IsPlanned,
                    IsGlobal = bRecord.IsGlobal,
                    PlannedStartDTS = bRecord.PlannedStartDTS,
                    PlannedEndDTS = bRecord.PlannedEndDTS,
                    IsActive = true,
                    CreateSystemUserID = 1,
                    UpdateSystemUserID = 1
                };

                await _unitOfWork.Repository<Cutting_Down_Header>().AddAsync(cuttingDownHeaderB);
                await _unitOfWork.SaveAsync();

                var cuttingDownDetailB = new Cutting_Down_Detail
                {
                    Cutting_Down_Key = cuttingDownHeaderB.Cutting_Down_Key,
                    Network_Element_Key = bRecord.Network_Element_Key,
                    ActualCreatetDate = bRecord.CreateDate,
                    ActualEndDate = bRecord.EndDate ?? bRecord.CreateDate,
                    ImpactedCustomers = 50
                };

                await _unitOfWork.Repository<Cutting_Down_Detail>().AddAsync(cuttingDownDetailB);
                await _unitOfWork.SaveAsync();

                transferredB++;
            }

            return new
            {
                CuttingDownARecordsTransferred = transferredA,
                CuttingDownBRecordsTransferred = transferredB
            };
        }



        //private bool ShouldIgnoreCuttingDownA(CuttingDownA aRecord)
        //{
        //    return aRecord.Network_Element_Key == null;
        //}

        //private bool ShouldIgnoreCuttingDownB(CuttingDownB bRecord)
        //{
        //    return bRecord.Network_Element_Key == null;
        //}

        //private async Task InsertIgnoredCuttingDownRecord(object record, string type)
        //{
        //    Cutting_Down_Ignored ignoredRecord = new Cutting_Down_Ignored
        //    {
        //        ActualCreatetDate = DateTime.UtcNow,
        //        SynchCreateDate = DateTime.UtcNow,
        //        CreatedUser = "System",
        //        Cabel_Name = type == "CuttingDownA" ? ((CuttingDownA)record).Cutting_Down_Cabin_Name : null,
        //        Cabin_Name = type == "CuttingDownB" ? ((CuttingDownB)record).Cutting_Down_Cable_Name : null
        //    };

        //    await _unitOfWork.Repository<Cutting_Down_Ignored>().AddAsync(ignoredRecord);
        //    await _unitOfWork.SaveAsync();
        //}
    }


}

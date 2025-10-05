import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CuttingDownSearchDto } from '../../Interfaces/CuttingDownMasterInterfaces/CuttingDownSearchDto';
import { CuttingDownSearchResultDto } from '../../Interfaces/CuttingDownMasterInterfaces/cuttingdownsearchResultDto';
import { AddCuttingDownDto } from '../../Interfaces/CuttingDownMasterInterfaces/AddCuttingDownDto';
import { CuttingDownResultDto } from '../../Interfaces/CuttingDownMasterInterfaces/CuttingDownResultDto';

@Injectable({
  providedIn: 'root'
})
export class CuttingDownMasterService {
  private apiUrl = 'https://localhost:7124/api/CuttingDownMaster';

  constructor(private http: HttpClient) {}

  searchTickets(dto: CuttingDownSearchDto): Observable<CuttingDownSearchResultDto> {
    return this.http.post<CuttingDownSearchResultDto>(`${this.apiUrl}/search`, dto);
  }

  addManualTicket(dto: AddCuttingDownDto): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/add-manual-ticket`, dto);
  }

  exportSearchResults(dto: CuttingDownSearchDto): Observable<Blob> {
    return this.http.post(`${this.apiUrl}/export`, dto, { responseType: 'blob' });
  }

 getTicketById(id: number): Observable<CuttingDownResultDto> {
    return this.http.get<CuttingDownResultDto>(`${this.apiUrl}/${id}`);
  }


}

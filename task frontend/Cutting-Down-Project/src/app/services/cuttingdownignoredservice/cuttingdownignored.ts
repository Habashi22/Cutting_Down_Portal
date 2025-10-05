import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CuttingDownIgnoredAddDto } from '../../Interfaces/CuttingDownIgnoreAddDto';
export interface IgnoredRecord {
  cutting_Down_Incident_ID: number;
  actualCreatetDate: string;
  synchCreateDate: string;
  cabel_Name?: string;
  cabin_Name?: string;
  createdUser: string;
}

@Injectable({
  providedIn: 'root'
})
export class CuttingDownIgnoredService {

  private baseUrl = 'https://localhost:7124/api/CuttingDownIgnored'; // 🔁 Adjust if needed

  constructor(private http: HttpClient) {}

  getAll(pageNumber: number = 1, pageSize: number = 10): Observable<any> {
    let params = new HttpParams()
      .set('pageNumber', pageNumber)
      .set('pageSize', pageSize);

    return this.http.get(this.baseUrl, { params });
  }



searchIgnored(query: string): Observable<IgnoredRecord[]> {
    return this.http.get<IgnoredRecord[]>(`${this.baseUrl}/search`, {
      params: { query }
    });
  }



    addIgnored(dto: CuttingDownIgnoredAddDto) {
    return this.http.post(`${this.baseUrl}`, dto);
  }


deleteIgnored(id: number) {
  return this.http.delete(`${this.baseUrl}/${id}`);
}


exportToExcel(): Observable<Blob> {
  return this.http.get(`${this.baseUrl}/export-excel`, {
    responseType: 'blob' // Important for binary file
  });
}

}




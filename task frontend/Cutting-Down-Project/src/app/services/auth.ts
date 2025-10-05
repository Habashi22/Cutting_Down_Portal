import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { RegisterUser } from '../Interfaces/register-user.model';
import { LoginUser } from '../Interfaces/LoginUser ';


interface ApiResponse<T> {
  isSuccess: boolean;
  message: string;
  response?: T;
}
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  register(user: RegisterUser): Observable<any> {
    const formData = new FormData();
    for (const key in user) {
      formData.append(key, (user as any)[key]);
    }

    return this.http.post(`${this.baseUrl}/Account/Register`, formData);
  }



login(loginUser: LoginUser): Observable<ApiResponse<any>> {
    // Using FormData because backend expects [FromForm]
    const formData = new FormData();
    formData.append('Email', loginUser.email);
    formData.append('Password', loginUser.password);

    return this.http.post<ApiResponse<any>>(`${this.baseUrl}/Account/Login`, formData);
  }

}

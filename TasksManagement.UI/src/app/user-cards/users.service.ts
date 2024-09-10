import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { User } from './user.model';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  private httpClient = inject(HttpClient);
  private apiUrl = environment.apiUrl;

  getUsers(): Observable<User[]> {
    return this.httpClient.get<User[]>(`${this.apiUrl}/People`);
  }

  getUser(id: string): Observable<User> {
    return this.httpClient.get<User>(`${this.apiUrl}/People/${id}`);
  }

  putUser(user: User): Observable<Object> {
    return this.httpClient.post(`${this.apiUrl}/People/${user.id}`, user);
  }

  postUser(user: User): Observable<Object> {
    return this.httpClient.post(`${this.apiUrl}/People/`, user);
  }

  deleteUser(id: string): Observable<Object> {
    return this.httpClient.delete(`${this.apiUrl}/People/${id}`);
  }
}

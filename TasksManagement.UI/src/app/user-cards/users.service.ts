import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { User } from './user.model';
import { Observable } from 'rxjs';
import { apiLink } from '../api.link';

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  private httpClient = inject(HttpClient);

  getUsers(): Observable<User[]> {
    return this.httpClient.get<User[]>(`${apiLink}/People`);
  }

  getUser(id: string): Observable<User> {
    return this.httpClient.get<User>(`${apiLink}/People/${id}`);
  }

  putUser(user: User): Observable<Object> {
    return this.httpClient.post(`${apiLink}/People/${user.id}`, user);
  }

  postUser(user: User): Observable<Object> {
    return this.httpClient.post(`${apiLink}/People/`, user);
  }

  deleteUser(id: string): Observable<Object> {
    return this.httpClient.delete(`${apiLink}/People/${id}`);
  }
}

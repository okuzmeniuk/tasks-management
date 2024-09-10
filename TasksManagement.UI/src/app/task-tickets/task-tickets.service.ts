import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TaskTicket } from './task-ticket.model';

@Injectable({
  providedIn: 'root',
})
export class TaskTicketsService {
  private httpClient = inject(HttpClient);
  private apiUrl = environment.apiUrl;

  getTaskTickets(): Observable<TaskTicket[]> {
    return this.httpClient.get<TaskTicket[]>(`${this.apiUrl}/TaskTickets`);
  }

  getTaskTicket(id: string): Observable<TaskTicket> {
    return this.httpClient.get<TaskTicket>(`${this.apiUrl}/TaskTickets/${id}`);
  }

  putTaskTicket(taskTicket: TaskTicket): Observable<Object> {
    return this.httpClient.post(
      `${this.apiUrl}/TaskTickets/${taskTicket.id}`,
      taskTicket
    );
  }

  postTaskTicket(taskTicket: TaskTicket): Observable<Object> {
    return this.httpClient.post(`${this.apiUrl}/TaskTickets/`, taskTicket);
  }

  deleteTaskTicket(id: string): Observable<Object> {
    return this.httpClient.delete(`${this.apiUrl}/TaskTickets/${id}`);
  }
}

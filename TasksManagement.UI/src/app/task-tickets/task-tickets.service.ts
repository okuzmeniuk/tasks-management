import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TaskTicket } from './task-ticket.model';
import { apiLink } from '../api.link';

@Injectable({
  providedIn: 'root',
})
export class TaskTicketsService {
  private httpClient = inject(HttpClient);

  getTaskTickets(): Observable<TaskTicket[]> {
    return this.httpClient.get<TaskTicket[]>(`${apiLink}/TaskTickets`);
  }

  getTaskTicket(id: string): Observable<TaskTicket> {
    return this.httpClient.get<TaskTicket>(`${apiLink}/TaskTickets/${id}`);
  }

  putTaskTicket(taskTicket: TaskTicket): Observable<Object> {
    return this.httpClient.post(
      `${apiLink}/TaskTickets/${taskTicket.id}`,
      taskTicket
    );
  }

  postTaskTicket(taskTicket: TaskTicket): Observable<Object> {
    return this.httpClient.post(`${apiLink}/TaskTickets/`, taskTicket);
  }

  deleteTaskTicket(id: string): Observable<Object> {
    return this.httpClient.delete(`${apiLink}/TaskTickets/${id}`);
  }
}

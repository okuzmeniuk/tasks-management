import { TaskTicket } from '../task-tickets/task-ticket.model';

export interface User {
  id: string;
  username: string;
  tickets: TaskTicket[];
}

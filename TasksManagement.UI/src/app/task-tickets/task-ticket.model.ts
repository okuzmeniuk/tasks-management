export interface TaskTicket {
  id: string;
  title: string;
  description: string;
  status: 'Open' | 'Closed';
  personId: string;
}

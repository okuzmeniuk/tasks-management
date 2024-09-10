import {
  ActivatedRouteSnapshot,
  ResolveFn,
  RouterStateSnapshot,
} from '@angular/router';
import { Observable } from 'rxjs';
import { inject } from '@angular/core';
import { UsersService } from '../user-cards/users.service';
import { User } from '../user-cards/user.model';

export const taskTicketsResolver: ResolveFn<Observable<User>> = (
  route: ActivatedRouteSnapshot,
  state: RouterStateSnapshot
) => {
  const url = route.url;
  const userId = url[url.length - 1].path;
  const usersService = inject(UsersService);
  return usersService.getUser(userId);
};

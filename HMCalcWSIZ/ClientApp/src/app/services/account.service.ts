import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AlertService } from './alert.service';
import { filter } from 'Rxjs/operators/filter';
import { User } from '../models/user';

@Injectable()
export class AccountService {

  private path: string;

  constructor(
    private http: HttpClient,
    private alertService: AlertService,
    @Inject('BASE_URL') private baseUrl: string) {
    this.path = baseUrl + '/account/';
  }

  changeEmail(email: string) {
    const temp = {
      email: email,
    };

    return this.http.put(this.path + 'changeEmail', temp);
  }

  changePassword(password: string) {
    const temp = {
      password: password,
    };

    return this.http.put(this.path + 'changePassword', temp);
  }

  getAllUsers() {
    return this.http.get<any>(this.baseUrl + 'users/getAllUsers');
  }

  updateUser(user: User) {
    const temp = {
      id: user.user_id,
      email: user.email,
      password: user.password,
    };
    return this.http.put<any>(this.path + 'updateUser', temp);
  }

  deleteUser(id: Number) {
    return this.http.delete<any>(this.path + 'delete/' + id.toString());
  }
}

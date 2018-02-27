import { Component } from '@angular/core';
import { User } from './User';
import {UserList} from './mock-users'

@Component({
    selector: 'app-users',
    templateUrl: './users.component.html'
})
export class UsersComponent {
   users = UserList;
}

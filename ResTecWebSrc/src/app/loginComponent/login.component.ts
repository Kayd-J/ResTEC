import { Component } from '@angular/core';
import {LoginInterface} from '../models/login.interface';
import {DataService} from '../data.service';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'loginScreen',
  templateUrl: './login.component.html' ,
  styleUrls: ['./login.component.css']
})
// tslint:disable-next-line:component-class-suffix
export class LoginScreen {
  loginUser: LoginInterface | undefined;
  constructor(private dataService: DataService) { }
  getLoginCredentials(username: string, password: string): void{
    this.dataService.getLoginCredentials({username, password} as LoginInterface).subscribe( data => this.loginUser = data);
  }

}

import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-window',
  templateUrl: './admin-window.component.html',
  styleUrls: ['./admin-window.component.css']
})
export class AdminWindowComponent implements OnInit {

  constructor() { }

  admin: boolean = true;

  ngOnInit(): void {
  }

  //Funciones que sustituyen el inicio de seccion de un cheff o admin
  cheffLog() { this.admin = false;}
  adminLog() { this.admin = true; }
}

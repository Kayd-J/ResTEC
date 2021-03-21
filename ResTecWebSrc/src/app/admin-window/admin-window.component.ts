import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';
import {OrderInterface} from '../models/order.interface';

@Component({
  selector: 'app-admin-window',
  templateUrl: './admin-window.component.html',
  styleUrls: ['./admin-window.component.css']
})
export class AdminWindowComponent implements OnInit {
  orders: OrderInterface[] | undefined;
  constructor(private dataService: DataService) { }

  admin: boolean = true;

  ngOnInit(): void {
    this.getAllOrders();
  }

  // Funciones que sustituyen el inicio de seccion de un cheff o admin
  cheffLog() { this.admin = false; }
  adminLog() { this.admin = true; }
  printOrder(): void{
  }

  getAllOrders(): void{
    this.dataService.getAllOrders().subscribe( data => this.orders = data);
  }
}

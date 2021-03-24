import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';
import {OrderInterface} from '../models/order.interface';
import {DishInterface} from '../models/dish.interface';
import {ClientInterface} from '../models/client.interface';

@Component({
  selector: 'app-admin-window',
  templateUrl: './admin-window.component.html',
  styleUrls: ['./admin-window.component.css']
})
export class AdminWindowComponent implements OnInit {
  orders: OrderInterface[] | undefined;
  topDishes: DishInterface[] | undefined;
  topClients: ClientInterface[] | undefined;
  topOrders: OrderInterface[] | undefined;
  constructor(private dataService: DataService) { }

  admin: boolean = true;

  ngOnInit(): void {
    this.getAllOrders();
    this.getBestSellingDishes();
  }

  // Funciones que sustituyen el inicio de seccion de un cheff o admin
  cheffLog() { this.admin = false; }
  adminLog() { this.admin = true; }

  getAllOrders(): void{
    this.dataService.getAllOrders().subscribe( data => this.orders = data);
  }

  private getBestSellingDishes() {
    this.dataService.getBestSellingDishes().subscribe( data => this.topDishes = data);
  }

  private getBestProfitDishes() {
    this.dataService.getBestProfitDishes().subscribe( data => this.topDishes = data);
  }

  private getOrdersByFeedback() {
    this.dataService.getOrdersByFeedback().subscribe( data => this.topOrders = data);
  }

  private getBestClientsByOrders() {
    this.dataService.getBestClientsByOrders().subscribe( data => this.topClients = data);
  }

  private takeOrder(idStr: string, chef: string)
  {
    const id = Number(idStr);
    const state = 'En progreso';
    const date = '';
    const time = 0;
    const prepTime = 0;
    const dishes = [0];
    this.dataService.updateOrder({id, date, time, prepTime, state, dishes, chef} as OrderInterface).subscribe();
  }

}

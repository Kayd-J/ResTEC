import { Component, OnInit } from '@angular/core';
import {OrderInterface} from '../models/order.interface';
import {DataService} from '../data.service';

@Component({
  selector: 'app-workbench',
  templateUrl: './workbench.component.html',
  styleUrls: ['./workbench.component.css']
})
export class WorkbenchComponent implements OnInit {

  chefEmail = 'erick.barrantes12@gmail.com';
  orders: OrderInterface[] | undefined;
  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.getOrdersByChef();
  }

  getOrdersByChef(): void{
    this.dataService.getOrderByChef(this.chefEmail).subscribe( data => this.orders = data);
  }

}

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

  private finishOrder(idStr: string, state: string)
  {
    const id = Number(idStr);
    const chef = '';
    const date = '';
    const time = 0;
    const prepTime = 0;
    const dishes = [0];
    this.dataService.updateOrder({id, date, time, prepTime, state, dishes, chef} as OrderInterface).subscribe();
  }

}

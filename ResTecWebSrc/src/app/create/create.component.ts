import { Component, OnInit } from '@angular/core';
import {DishInterface} from '../models/dish.interface';
import {DataService} from '../data.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  constructor(private dataService: DataService) { }

  plate: boolean = true;
  dish: DishInterface | undefined;

  ngOnInit(): void {
  }

  addDish(name: string, description: string, price: number): void {
    const ingredients: Array<string> = [];
    const amountSales = 0;
    const prepTime = 0;
    this.dataService.addDish({ name, description, price, amountSales, ingredients, prepTime} as DishInterface).subscribe();
  }

}

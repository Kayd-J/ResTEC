import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';
import { DishInterface } from '../models/dish.interface';

@Component({
  selector: 'app-admin-window',
  templateUrl: './admin-window.component.html',
  styleUrls: ['./admin-window.component.css']
})
export class AdminWindowComponent implements OnInit {
  dishes: DishInterface[] | undefined;
  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.dataService.getAllDishes().subscribe( data => this.dishes = data);
  }

  addDish(name: string, description: string, price: number,  amountSales: number,  prepTime: number): void {
    const ingredients: Array<string> = [];
    this.dataService.addDish({ name, description, price, amountSales, ingredients, prepTime} as DishInterface)
      .subscribe(dish => {
        // @ts-ignore
        this.dishes.push(dish);
      });
  }

}

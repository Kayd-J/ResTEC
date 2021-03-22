import { Component, OnInit } from '@angular/core';
import {DataService} from '../data.service';
import {DishInterface} from '../models/dish.interface';
import {MenuInterface} from '../models/menu.interface';

@Component({
  selector: 'app-update-table',
  templateUrl: './update-table.component.html',
  styleUrls: ['./update-table.component.css']
})
export class UpdateTableComponent implements OnInit {

  dishes: DishInterface[] | undefined;
  menus: MenuInterface[] | undefined;
  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.getAllDishes();
    this.getAllMenus();
    }

  getAllDishes(): void{
    this.dataService.getAllDishes().subscribe( data => this.dishes = data);
  }

  getAllMenus(): void{
    this.dataService.getAllMenus().subscribe( data => this.menus = data);
  }

  updateMenu(idStr: string, type: string, caloriesStr: string, dishes: number[]): void {
    const price = 0;
    const id = Number(idStr);
    const calories = Number(caloriesStr);
    this.dataService.updateMenu({id, type, calories, dishes, price} as MenuInterface).subscribe();
  }

  updateDish(idStr: string, name: string, description: string, priceStr: string,
             ingredients: string[], amountSalesStr: string, prepTimeStr: string ): void {
    const id = Number(idStr);
    const price = Number(priceStr);
    const amountSales = Number(amountSalesStr);
    const prepTime = Number(prepTimeStr);
    this.dataService.updateDish({id, name, description, price, amountSales, ingredients, prepTime} as DishInterface).subscribe();
  }

  deleteDish(idStr: string): void{
    const id = Number(idStr);
    this.dataService.deleteDish(id).subscribe();
  }

  deleteMenu(idStr: string): void{
    const id = Number(idStr);
    this.dataService.deleteMenu(id).subscribe();
  }

}

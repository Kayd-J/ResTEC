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

}

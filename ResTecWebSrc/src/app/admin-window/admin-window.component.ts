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

}

import { Component, OnInit } from '@angular/core';
import {DataService} from '../data.service';
import {MenuInterface} from '../models/menu.interface';

@Component({
  selector: 'app-create-menu',
  templateUrl: './create-menu.component.html',
  styleUrls: ['./create-menu.component.css']
})
export class CreateMenuComponent implements OnInit {

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
  }

  addMenu(type: string, calories: number): void {
    const dishes: Array<number> = [];
    const price = 0;
    this.dataService.addMenu({type, calories, dishes, price} as MenuInterface).subscribe();
  }

}

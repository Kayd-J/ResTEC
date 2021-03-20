import { Injectable } from '@angular/core';
import { DishInterface } from './models/dish.interface';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http: HttpClient) { }

  getAllDishes(): Observable<DishInterface[]> {
    return this.http.get<DishInterface[]>('/api/dishes');
  }
}

import { Injectable } from '@angular/core';
import { DishInterface } from './models/dish.interface';
import {Observable, of} from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {MessageService} from './message.service';
import {MenuInterface} from './models/menu.interface';
import {OrderInterface} from './models/order.interface';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  private dishesUrl = '/api/dishes/';
  private menusUrl = '/api/menus/';
  private ordersUrl = '/api/orders/';
  private reportsUrl = '/api/reports/';
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  constructor(private http: HttpClient, private  messageService: MessageService) { }

  getAllDishes(): Observable<DishInterface[]> {
    this.messageService.add('DataService: fetched dishes');
    return this.http.get<DishInterface[]>(this.dishesUrl)
      .pipe(
        catchError(this.handleError<DishInterface[]>('getAllDishes', []))
      );
  }

  addDish(dish: DishInterface): Observable<DishInterface> {
    return this.http.post<DishInterface>(this.dishesUrl, dish, this.httpOptions).pipe(
      tap((newDish: DishInterface) => this.log(`added dish w/ id=${newDish.id}`)),
      catchError(this.handleError<DishInterface>('addDish'))
    );
  }

  getAllMenus(): Observable<MenuInterface[]> {
    this.messageService.add('DataService: fetched menus');
    return this.http.get<MenuInterface[]>(this.menusUrl)
      .pipe(
        catchError(this.handleError<MenuInterface[]>('getAllMenus', []))
      );
  }

  addMenu(menu: MenuInterface): Observable<MenuInterface> {
    return this.http.post<MenuInterface>(this.menusUrl, menu, this.httpOptions).pipe(
      tap((newMenu: MenuInterface) => this.log(`added menu w/ id=${newMenu.id}`)),
      catchError(this.handleError<MenuInterface>('addMenu'))
    );
  }

  getAllOrders(): Observable<OrderInterface[]> {
    this.messageService.add('DataService: fetched orders');
    return this.http.get<OrderInterface[]>(this.ordersUrl)
      .pipe(
        catchError(this.handleError<OrderInterface[]>('getAllOrders', []))
      );
  }

  getOrderByChef(email: string): Observable<OrderInterface[]> {
    this.messageService.add('DataService: fetched orders');
    return this.http.get<OrderInterface[]>(this.ordersUrl + email)
      .pipe(
        catchError(this.handleError<OrderInterface[]>('getAllOrders', []))
      );
  }

  // tslint:disable-next-line:typedef
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  getBestSellingDishes(): Observable<DishInterface[]> {
    this.messageService.add('DataService: fetched best selling dishes');
    return this.http.get<DishInterface[]>(this.reportsUrl + 'topselling')
      .pipe(
        catchError(this.handleError<DishInterface[]>('getAllDishes', []))
      );
  }

  // tslint:disable-next-line:typedef
  private log(message: string) {
    this.messageService.add(`DataService: ${message}`);
  }


}

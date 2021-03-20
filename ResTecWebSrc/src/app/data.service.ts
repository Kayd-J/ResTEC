import { Injectable } from '@angular/core';
import { DishInterface } from './models/dish.interface';
import {Observable, of} from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {MessageService} from './message.service';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  private dishesUrl = '/api/dishes';
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

  // tslint:disable-next-line:typedef
  private log(message: string) {
    this.messageService.add(`HeroService: ${message}`);
  }


}

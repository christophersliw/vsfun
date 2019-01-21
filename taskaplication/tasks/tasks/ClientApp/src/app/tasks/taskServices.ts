import {EventEmitter, Injectable, Output} from '@angular/core';
import {Task} from "./task";
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {catchError} from "rxjs/operators";
import 'rxjs/add/operator/map';
import { map } from 'rxjs/operators';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' })
};

@Injectable({
  providedIn: 'root',
})
export class TaskService {

  @Output() refreshListEvent = new EventEmitter();

  private taskUrl = 'api/tasks';  // URL to web api

  constructor(private http: HttpClient) { }

  getTasks(): Observable<Task[]>{
    return this.http.get<Task[]>(this.taskUrl)
  }

  updateTask (id:number, task: Task): Observable<any> {
    return this.http.put(this.taskUrl + '/' + id, task, httpOptions);
  }

  addTask(task: Task): Observable<Task>{
    return this.http.post(this.taskUrl, task, httpOptions).pipe(map((task) => new Task()));
  }

  refreshList(){
    this.refreshListEvent.emit();
  }

}

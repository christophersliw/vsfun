import { Injectable } from '@angular/core';
import {Task} from "./task";
import {Tasks} from "./mock-tasks";
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class TaskService {

  private taksUrl = 'api/tasks';  // URL to web api

  constructor(private http: HttpClient) { }

  getTasks(): Observable<Task[]>{
    return this.http.get<Task[]>(this.taksUrl)
  }

}

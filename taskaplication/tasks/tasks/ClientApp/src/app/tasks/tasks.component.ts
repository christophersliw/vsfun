import { Component, OnInit } from '@angular/core';
import {Task} from "./task";
import {Tasks} from "./mock-tasks";
import {TaskService} from "./TaskServices";

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit {

  selectedTask: Task;
  editedTask: Task;
  tasks : Task[];

  constructor(private taskService: TaskService) { }

  ngOnInit() {
    this.getTasks();
    this.taskService.refreshListEvent.subscribe(item => {
      this.refreshList();
    });
  }

  onSelect(task: Task):void{
    this.selectedTask = task;

    this.editedTask = new Task();
    this.editedTask.description = task.description;
    this.editedTask.id = task.id;
    this.editedTask.title = task.title;
  }

  getTasks():void{
    this.taskService.getTasks().subscribe(tasks =>this.tasks = tasks);
  }

  add(title: string): void {
    title = title.trim();
    if (!title) { return; }
    this.taskService.addTask({ title } as Task)
      .subscribe(task => {
        this.tasks.push(task);
      });
  }

  refreshList():void{
    this.getTasks();
  }

}

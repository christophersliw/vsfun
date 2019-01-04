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

}

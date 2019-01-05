import { Component, OnInit, Input } from '@angular/core';
import {Task} from "../tasks/task";
import {TaskService} from "../tasks/TaskServices";

@Component({
  selector: 'app-task-details',
  templateUrl: './task-details.component.html',
  styleUrls: ['./task-details.component.css']
})

export class TaskDetailsComponent implements OnInit {
  @Input() selectedTask: Task;
  @Input() editedTask: Task;
  constructor(private taskService: TaskService) { }

  ngOnInit() {
  }

  updateTaskList(task: Task):void{

  }

  save(): void {
    this.taskService.updateTask(this.selectedTask.id, this.editedTask)
      .subscribe(() => this.updateTaskList(this.editedTask));
  }

}

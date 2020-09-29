import { Component, OnInit } from '@angular/core';
import { MatSelectModule } from '@angular/material/select';

@Component({
  selector: 'app-workflow-actions',
  templateUrl: './workflow-actions.component.html',
  styleUrls: ['./workflow-actions.component.css']
})
export class WorkflowActionsComponent implements OnInit {
  transitions: string[] = ["action1", "action2"];

  constructor() { }

  ngOnInit(): void {
  }

}

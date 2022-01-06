import { Component, OnInit } from '@angular/core';
import { EventList } from '../event-list';
import { EventListService } from '../event-list.service';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.css']
})
export class EventListComponent implements OnInit {
  events: EventList[] = [];

  constructor(private eventListService : EventListService) { }

  ngOnInit(): void {
    this.getEvents();
  }

  getHeroes(): void {
    this.getEvents()
    .subscribe(events => this.events = events);
  }
}

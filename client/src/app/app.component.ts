import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'client';
  posts: any;

  constructor(private http: HttpClient) {

  }
  ngOnInit(): void {
    this.http.get('http://localhost:5202/api/posts').subscribe({
      next: (response) => this.posts = response,
      error: (e) => console.error(e),
      complete: () => console.log('complete')
    })
  }
}

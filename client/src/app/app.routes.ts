import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CreatePostComponent } from './create-post/create-post.component';
import { ViewPostComponent } from './view-post/view-post.component';

export const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'create', component: CreatePostComponent },
    { path: 'posts/:id', component: ViewPostComponent },
    { path: '**', component: HomeComponent, pathMatch: 'full' }
];

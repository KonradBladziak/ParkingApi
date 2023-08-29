import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatTableModule} from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatTableDataSourcePaginator } from '@angular/material/table';
import {Component} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {NgFor} from '@angular/common';
import {MatSelectModule} from '@angular/material/select';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MiastoListComponent } from './Miasto/miasto-list/miasto-list.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ParkingListComponent } from './Parking/parking-list/parking-list.component';
import { MiejscaListComponent } from './Miejsca/miejsca-list/miejsca-list.component';

@NgModule({
  declarations: [
    AppComponent,
    MiastoListComponent,
    ParkingListComponent,
    MiejscaListComponent
  ],
  imports: [
    MatFormFieldModule, MatSelectModule, NgFor, MatInputModule, FormsModule,
    MatSlideToggleModule,
    MatTableModule,
    MatToolbarModule,
    MatButtonModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatIconModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

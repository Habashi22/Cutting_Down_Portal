import { Component, OnInit } from '@angular/core';
import { CommonModule, NgIf, NgFor } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';


import {
  CuttingDownIgnoredService,
  IgnoredRecord
} from '../../../services/cuttingdownignoredservice/cuttingdownignored';

@Component({
  selector: 'app-cutting-down-ignored',
  templateUrl: './cuttingdown-ignored.html',
  styleUrl: './cuttingdown-ignored.css',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    NgIf,
    NgFor
  ]
})
export class CuttingDownIgnoredComponent implements OnInit {
  ignoredList: IgnoredRecord[] = [];
  pageNumber = 1;
  pageSize = 5;

  // Search
  query = '';
  results: IgnoredRecord[] = [];
  isLoading = false;
  error: string | null = null;

  // Messages
  successMessage = '';
  errorMessage = '';

  constructor(private ignoredService: CuttingDownIgnoredService) {}

  ngOnInit(): void {
    this.loadIgnoredData();
  }

  loadIgnoredData(): void {
    this.ignoredService.getAll(this.pageNumber, this.pageSize).subscribe({
      next: (res) => {
        this.ignoredList = res;
      },
      error: (err) => {
        console.error('Error loading ignored items:', err);
      }
    });
  }

  nextPage(): void {
    this.pageNumber++;
    this.loadIgnoredData();
  }

  previousPage(): void {
    if (this.pageNumber > 1) {
      this.pageNumber--;
      this.loadIgnoredData();
    }
  }

  search(): void {
    this.isLoading = true;
    this.error = null;
    this.results = [];

    this.ignoredService.searchIgnored(this.query).subscribe({
      next: (res) => {
        this.results = res;
        this.isLoading = false;
      },
      error: (err) => {
        this.error = err?.message || 'Something went wrong';
        this.isLoading = false;
      }
    });
  }

  fetchRecords(): void {
    // Called after deletion
    this.ignoredService.getAll(this.pageNumber, this.pageSize).subscribe({
      next: (res) => {
        this.ignoredList = res;
      },
      error: (err) => {
        console.error('Error fetching records after delete:', err);
      }
    });
  }

  deleteRecord(id: number): void {
    if (!confirm('Are you sure you want to delete this record?')) return;

    this.ignoredService.deleteIgnored(id).subscribe({
      next: () => {
        this.successMessage = 'l';
        this.errorMessage = '';
        this.fetchRecords();
      },
      error: (err) => {
        this.errorMessage = 'Failed to delete the record.';
        this.successMessage = '';
        console.error(err);
      }
    });
  }

exportExcel(): void {
  this.ignoredService.exportToExcel().subscribe({
    next: (blob) => {
      const url = window.URL.createObjectURL(blob);
      const a = document.createElement('a');
      a.href = url;
      a.download = 'IgnoredIncidents.xlsx';
      a.click();
      window.URL.revokeObjectURL(url);
    },
    error: (err) => {
      console.error('Export failed:', err);
    }
  });
}



}

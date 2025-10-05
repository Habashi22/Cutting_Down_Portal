import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CuttingDownIgnoredService } from '../../../services/cuttingdownignoredservice/cuttingdownignored';

@Component({
  selector: 'app-addcuttingdownignored',
  standalone: true, // ✅ Needed for standalone components
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './addcuttingdownignored.html',
  styleUrl: './addcuttingdownignored.css'
})
export class Addcuttingdownignored implements OnInit {
  addForm!: FormGroup;
  successMessage = '';
  errorMessage = '';

  constructor(
    private fb: FormBuilder, // ✅ Inject FormBuilder
    private ignoredService: CuttingDownIgnoredService
  ) {}

  // ✅ Initialize the form group here
  ngOnInit(): void {
    this.addForm = this.fb.group({
      actualCreatetDate: ['', Validators.required],
      synchCreateDate: ['', Validators.required],
      cabel_Name: [''],
      cabin_Name: [''],
      createdUser: ['']
    });
  }

  onSubmit(): void {
    if (this.addForm.invalid) return;

    this.ignoredService.addIgnored(this.addForm.value).subscribe({
      next: () => {
        this.successMessage = 'Record added successfully!';
        this.errorMessage = '';
        this.addForm.reset();
      },
      error: (err) => {
        this.errorMessage = 'Failed to add record.';
        this.successMessage = '';
        console.error(err);
      }
    });
  }
}

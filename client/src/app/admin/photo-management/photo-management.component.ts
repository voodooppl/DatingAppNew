import { Component, inject, OnInit } from '@angular/core';
import { AdminService } from '../../_services/admin.service';
import { MembersService } from '../../_services/members.service';
import { Photo } from '../../_models/photo';

@Component({
  selector: 'app-photo-management',
  standalone: true,
  imports: [],
  templateUrl: './photo-management.component.html',
  styleUrl: './photo-management.component.css'
})
export class PhotoManagementComponent implements OnInit {
  private memberService = inject(MembersService);
  private adminService = inject(AdminService);
  photosToApprove: Photo[] = [];

  ngOnInit(): void {
    this.getPhotosForApproval();
  }

  getPhotosForApproval() {
    this.adminService.getPhotosForApproval().subscribe({
      next: photos => this.photosToApprove = photos
    });
  }

  approvePhoto(photoId: number) {
    this.adminService.approvePhoto(photoId).subscribe({
      next: () => {
        this.getPhotosForApproval();
      }
    });
  }

  rejectPhoto(photoId: number) {
    this.adminService.rejectPhoto(photoId).subscribe({
      next: () => {
        this.getPhotosForApproval();
      }
    })
  }

}

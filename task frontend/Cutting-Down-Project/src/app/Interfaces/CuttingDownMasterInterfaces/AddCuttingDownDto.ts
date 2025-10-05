export interface AddCuttingDownDto {
  channelKey: number;
  problemTypeKey: number;
  actualCreatedDate: string; // was Date
  actualEndDate?: string;
  isPlanned: boolean;
  isGlobal: boolean;
  plannedStartDTS?: string;
  plannedEndDTS?: string;
  createSystemUserID: number;
  updateSystemUserID: number;
  networkElementKey?: number;
  impactedCustomers: number;
}

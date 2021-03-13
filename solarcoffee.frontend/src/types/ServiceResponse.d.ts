export interface ServiceResponse<T> {
  isSuccess: boolean;
  message: string;
  time: Date;
  data: T;
}

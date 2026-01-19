export enum BookStatus {
  Available = 0,
  Taken = 1,
  Reserved = 2
}

export const bookStatusOptions = [
  { value: BookStatus.Available, key: '::Enum:Status.Available', class: 'badge bg-success' },
  { value: BookStatus.Taken, key: '::Enum:Status.Taken', class: 'badge bg-warning text-dark' },
  { value: BookStatus.Reserved, key: '::Enum:Status.Reserved', class: 'badge bg-info' },
];
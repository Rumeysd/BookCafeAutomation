export enum BookStatus {
  Available = 0,
  Borrowed = 1,
  Reserved = 2
}

export const bookStatusOptions = [
  {
    value: 0,
    key: 'Enum:Status.Available', // JSON'daki anahtar ile birebir aynı olmalı
    class: 'badge bg-success'
  },
  {
    value: 1,
    key: 'Enum:Status.Taken',
    class: 'badge bg-warning'
  },
  {
    value: 2,
    key: 'Enum:Status.Reserved',
    class: 'badge bg-danger'
  }
];
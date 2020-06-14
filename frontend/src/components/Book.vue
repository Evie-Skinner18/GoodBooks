<template>
    <div class="book-wrapper">
        <div class="book-title"> {{ book.title }} </div>
        <div class="book-author"> {{ book.author }} </div>
        <div class="book-created"> {{ book.createdOn | humanise }} </div>
        <div class="delete-button" @click="deleteBook(book.id)"> X </div>
    </div>
</template>


<script lang="ts">
  import { Component, Prop, Vue } from 'vue-property-decorator'; 
  import IBook from '@/types/Book';
  import BookService from '@/services/book-service';

  const bookService = new BookService();

  @Component({
      name: "Book",
      components: {}

  })
  export default class Book extends Vue {
      // pass up a prop, a book, and the type of that is IBook
      @Prop({ required: true })
      book!: IBook;

      // methods
      deleteBook(id: number) {
          bookService.deleteBook(id);
          this.$emit('deleted');
      }
  }

</script>

<!-- scoped means the styles here will only apply to this component  -->
<style scoped lang="scss">
    .book-wrapper {
        margin-left: 30%;
        margin-bottom: 1%;
        width: 40%;
        background: rgb(241, 226, 206);
        position: relative;
        padding: 0.7%;
        border: 5px double #fbd157;
        border-radius: 1rem;
        box-shadow: 0 1px 3px rgba(0,0,0,0.12), 0 1px 2px rgba(0,0,0,0.24);
    }
    .book-wrapper:hover {
        box-shadow: 0 14px 28px rgba(0,0,0,0.25), 0 10px 10px rgba(0,0,0,0.22);
    }

    .book-title {
        font-weight: bold;
    }

    .book-created {
        font-size: small;
    }

    .delete-button {
        color: firebrick;
        font-weight: bolder;
        position: absolute;
        top: 10px;
        right: 10px;
        cursor: pointer;
    }
    .delete-button:hover {
        color: red;
    }

</style>
<template>
  <div class="books-container">
    <h1>My Books</h1>
    <div v-show="myBooks.length">
      <!-- <div v-for="book in myBooks" :key="book.id">
        {{ book.title }} - {{ book.author }}
      </div> -->
      <!-- book is a prop being passed up to Books from Book component -->
      <book :book="book" v-for="book in myBooks" :key="book.id">

      </book>
    </div>
  </div>
</template>

<script lang="ts">
  import { Component, Vue } from 'vue-property-decorator'; 
  import Book from '@/components/Book.vue';
  import IBook from '@/types/Book' ;
  import BookService from '@/services/book-service';

  const bookService = new BookService();

  @Component({
    name: 'Books',
    // any subcomponents go here
    components: { Book }
  })

  export default class Books extends Vue {
    // data
    myBooks: IBook[] = [];
    // computed properties
    get numberOfBooks(){
      return this.myBooks.length;
    }
    // props

    // methods

    // lifecycle hooks
    // created means before the component fully mounts
    async created() {
      //this.myBooks = await bookService.getAllBooks();
        bookService.getAllBooks().then(response => this.myBooks = response); 
    }

  }
</script>

<style lang="scss">

</style>

<template>
  <div class="books-container">
    <h1>My Books</h1>
    <div v-show="myBooks.length">     
      <!-- book is a prop being passed up to Books from Book component. when any books emits the 'deleted' event, it will re-request getAllBooks().
        @deleted in parent component links with 'deleted' in child component -->
      <book @deleted="getAllBooks" :book="book" v-for="book in myBooks" :key="book.id"></book>
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

    // methods
    getAllBooks() {
      bookService.getAllBooks()
              .then(response => this.myBooks = response)
              .catch(error => console.error(error));
    }

    // 'created' lifecycle hook means do this before the component fully mounts
    created() {
      this.getAllBooks();
    }

  }
</script>

<style lang="scss">

</style>

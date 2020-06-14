<template>
    <div class="add-book-wrapper">
        <h1>Add a new book!</h1>
        <div class="add-book-form">
            <ul>
                <li class="new-book">
                    <label for="title"> Title </label>
                    <div>
                        <input type="text" id="title" v-model="book.title">
                    </div>
                </li>
                <li class="new-book">
                    <label for="author"> Author </label>
                    <div>
                        <input type="text" id="author" v-model="book.author">
                    </div>
                </li>                
            </ul>
            <!-- bind the button's click event to submitBook method -->
            <button :disabled="isButtonDisabled" @click="addBook"> Add </button>
        </div>
    </div>
</template>


<script lang="ts">
  import { Component, Vue } from 'vue-property-decorator'; 
  import IBook from '@/types/Book';
  import BookService from '@/services/book-service';

  const bookService = new BookService();

  @Component({
      name: "AddBook",
      components: {}

  })
  export default class AddBook extends Vue {
      book: IBook = {
          title: "",
          author: ""
      };

      // methods
      addBook() {
          bookService.addNewBook(this.book);
      }

      get isButtonDisabled() {
          let formHasNoInput = this.book.title === "" || this.book.author === "";
          return formHasNoInput;
      }
  }

</script>

<style scoped lang="scss">    

    .new-book {
        list-style: none;
        padding: 0;
        margin: 0;
    }
</style>
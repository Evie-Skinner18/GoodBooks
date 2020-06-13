<template>
    <div class="book-wrapper">
        <div class="book-title"> {{ book.title }} </div>
        <div class="book-author"> {{ book.author }} </div>
        <div class="book-created"> {{ book.createdOn }} </div>
        <div class="delete-button"> X </div>
    </div>
</template>


<script lang="ts">
  import { Component, Prop, Vue } from 'vue-property-decorator'; 
  import IBook from '@/types/Book';

  @Component({
      name: "Book",
      components: {}

  })
  export default class Book extends Vue {
      // pass up a prop, a book, and the type of that is IBook
      @Prop({ required: true })
      book!: IBook;
  }

</script>

<!-- scoped means the styles here will only apply to this component  -->
<style scoped lang="scss">
    .book-wrapper {
        position: relative;
        margin: 0.8rem;
        padding: 0.6rem;
        border: 5px double #fbd157;
        border-radius: 1rem;
    }
    .book-title {
        font-weight: bold;
    }

    .book-created {
        font-size: small;
    }

    .delete-button {
        color: red;
        font-weight: bolder;
    }
</style>
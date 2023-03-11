<template>
  <div id="expense">
    <h1>Expense Index - Vue</h1>
    <p>
        <router-link :to="{ name: 'CreateExpenses' }">Create new</router-link> 
    </p>
    <table class="table">
        <thead>
            <tr>
                <th>
                    id
                </th>
                <th>
                    name
                </th>
                <th>
                    amount ($)
                </th>
                <th>
                    date
                </th>
                <th></th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="expense in expenses" :key="expense.id">
                <td>
                    {{expense.id}}
                </td>
                <td>
                    {{expense.name}}
                </td>
                <td>
                    {{expense.amount}}
                </td>
                <td>
                    {{expense.date}}
                </td>
                <td>
                    <router-link :to="{ name: 'EditExpenses', params: { id: expense.id}}">Edit</router-link> |
                    <router-link :to="{ name: 'DetailsExpenses', params: { id: expense.id}}">Details</router-link> |
                    <router-link :to="{ name: 'DeleteExpenses', params: { id: expense.id}}">Delete</router-link> 
                </td>
            </tr>
         </tbody>
    </table>
</div>
</template>

<script>
    export default {
    data() {
        return {
            expenses: [
                { id: 1, name: 'Grocery', amount: 50, date: '2023.03.11'}
            ]
        }
    }
}
</script>

<style>

</style>
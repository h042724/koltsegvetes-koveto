<template>
    <div id="expense">
        <h1>Expense details - Vue</h1>
        <dl class="row">
            <dt class="col-sm-2">
                <label>ID</label>
            </dt>
            <dd class="col-sm-10">
                {{ id }}
            </dd>
            <!--<dt class="col-sm-2">
                <label>Category</label>
            </dt>
            <dd class="col-sm-10">
                {{Expense.Category}}
            </dd>
            <dt class="col-sm-2">
                <label>Transaction Date</label>
            </dt>
            <dd class="col-sm-10">
                {{Expense.TransactionDate}}
            </dd>
            <dt class="col-sm-2">
                <label>User Guid</label>
            </dt>
            <dd class="col-sm-10">
                {{Expense.UserGuid}}
            </dd>-->
        </dl>
        <div>
            <router-link :to="{ name: 'EditExpenses', params: { id: id}}">Edit</router-link> |
            <router-link :to="{ name: 'IndexExpenses' }">Back to List</router-link>
        </div>
    </div>
</template>

<script>
export default {
    props: ['id']
}
</script>

<style>

</style>
<template>
    <div id="expense">
        <h1>Expense delete - Vue</h1>
        <h3>Are you sure you want to delete this?</h3>
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
        <form method="post">
            <input type="hidden" name="id" value="id" />
            <input type="submit" value="Delete" class="btn btn-danger" /> |
            <router-link :to="{ name: 'IndexExpenses' }">Back to List</router-link>
        </form>
    </div>
</template>

<script>
export default {
    props: ['id']
}
</script>

<style>

</style>
<template>
    <div id="expense">
        <h1>Expense edit - Vue</h1>
        <form method="post">
            <div class="row">
                <div class="col-md-4">
                    <div class="text-danger"></div>
                    <input type="number" name="Id" :value="id" />
                    <!--<div class="form-group">
                        <label for="Name" class="control-label">Expense Name</label>
                        <input name="Name" class="form-control" :value="Expense.Name" />
                    </div>
                    <div class="form-group">
                        <label for="Category" class="control-label">Category</label>
                        <input name="Category" class="form-control" :value="Expense.Category" />
                    </div>
                    <div class="form-group">
                        <label for="TransactionDate" class="control-label">Transaction Date</label>
                        <input name="TransactionDate" class="form-control" :value="Expense.TransactionDate" />
                    </div>
                    <div class="form-group">
                        <label for="UserGuid" class="control-label">User Guid</label>
                        <input name="UserGuid" class="form-control" :value="Expense.UserGuid" />
                    </div>-->
                    <div class="form-group">
                        <input type="submit" value="Save" class="btn btn-primary" />
                    </div>
                </div>
            </div>
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
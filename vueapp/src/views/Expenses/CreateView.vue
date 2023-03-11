<template>
    <div id="expense">
        <h1>Expense Create - Vue</h1>
        <form :action="CreateExpenseUrl" method="post">
            <div class="row">
                <div class="col-md-4">
                    <div asp-validation-summary="ModelOnly" class="text-danger"></div>
                    <div class="form-group">
                        <label for="Name" class="control-label">Név:</label>
                        <input name="Name" class="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="Category" class="control-label">Kategória:</label>
                        <input name="Category" class="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="TransactionDate" class="control-label">Tranzakció dátuma</label>
                        <input name="TransactionDate" class="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="UserGuid" class="control-label">User Guid</label>
                        <input name="UserGuid" class="form-control" />
                    </div>
                    <div class="form-group">
                        <input type="submit" value="Create" class="btn btn-primary" />
                    </div>
                </div>
            </div>
        </form>
    </div>
</template>

<script>
export default {

}
</script>

<style>

</style>
<template>
    <div id="expense">
        <h1>Expense Create - VUe</h1>
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

<script lang="js">
    import { defineComponent } from 'vue';

    export default defineComponent({
        name: 'expense-create-component',
        props: {
            CreateExpenseUrl: String
        },
        /*data() {
            return {
                loading: false,
                post: null
            };
        },
        created() {
            // fetch the data when the view is created and the data is
            // already being observed
            this.fetchData();
        },
        watch: {
            // call again the method if the route changes
            '$route': 'fetchData'
        },
        methods: {
            fetchData() {
                this.post = null;
                this.loading = true;

                fetch('weatherforecast')
                    .then(r => r.json())
                    .then(json => {
                        this.post = json;
                        this.loading = false;
                        return;
                    });
            }
        },*/
    });
</script>
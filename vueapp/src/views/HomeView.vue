<template>
    <div class="home">
        <h1>Homepage</h1>
    </div>
    <div class="post">
        <div v-if="loading" class="loading"></div>
        <div v-if="post" class="content">
            <table>
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Temp. (C)</th>
                        <th>Temp. (F)</th>
                        <th>Summary</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="forecast in post" :key="forecast.date">
                        <td>{{ forecast.date }}</td>
                        <td>{{ forecast.temperatureC }}</td>
                        <td>{{ forecast.temperatureF }}</td>
                        <td>{{ forecast.summary }}</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

<script>
export default {
    name: 'HomeView',
    components: {},
    data() {
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
    },
}
</script>
